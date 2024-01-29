import { useEffect, useState } from "react"
import { getStudents } from "../../managers/studentManager"
import { getRepertoires } from "../../managers/repertoireManager"
import { Button, Col, Form, FormGroup, Input, Label } from "reactstrap"
import { addLesson } from "../../managers/lessonManager"
import { useNavigate } from "react-router-dom"

export const AddLesson = () => {
  const [students, setStudents] = useState([])
  const [repertoires, setRepertoires] = useState([])
  const [selectedStudent, setSelectedStudent] = useState(0)
  const [selectedDate, setSelectedDate] = useState("")
  const [selectedTime, setSelectedTime] = useState("")
  const [selectedPrice, setSelectedPrice] = useState(20)
  const [selectedRepertoires, setSelectedRepertoires] = useState([])

  const navigate = useNavigate()

  useEffect(() => {
    getStudents().then(arr => setStudents(arr))
    getRepertoires().then(arr => setRepertoires(arr))
  }, [])

  const handleRepertoireChange = (e) => {
    const selectedRepertoireId = e.target.value
    const selectedRepertoire = repertoires.find(r => r.id === parseInt(selectedRepertoireId))
    if (selectedRepertoire && !selectedRepertoires.some((r) => r.id === selectedRepertoire.id)) {
      setSelectedRepertoires((prevRepertoires) => [...prevRepertoires, selectedRepertoire])
    }
  }

  const handleAddLessonBtn = (e) => {
    e.preventDefault()

    const formattedDateAndTime = selectedDate + "T" + selectedTime + ":00"
    const lessonRepertoiresArray = selectedRepertoires.map(sr => ({ repertoireId: sr.id }));

    const lessonToAdd = {
      studentId: selectedStudent,
      dateScheduled: formattedDateAndTime,
      isCompleted: false,
      price: selectedPrice,
      isPaid: false,
      lessonRepertoires: lessonRepertoiresArray
    }
    console.log(lessonToAdd)
    addLesson(lessonToAdd).then(() => navigate("/lessons"))
  }

  return (
    <div className="container">
      <h2>Schedule New Lesson</h2>
      <Form className="new-lesson-form">
        <FormGroup>
          <Label for="studentSelect">
            Student
          </Label>
          <Col sm={10}>
            <Input
              id="studentSelect"
              type="select"
              // value={students.id}
              onChange={e => setSelectedStudent(parseInt(e.target.value))}
            >
              <option value="0">Choose a student</option>
              {students
                .filter(student => student.isActive)
                .map(s => (
                <option key={s.id} value={s.id}>{s.userProfile.firstName} {s.userProfile.lastName}</option>
              ))}
            </Input>
          </Col>
        </FormGroup>
        <FormGroup>
          <Label>Date Scheduled</Label>
          <Col sm={10}>
            <Input
              type="date"
              value={selectedDate}
              onChange={e => setSelectedDate(e.target.value)}
            />
          </Col>
        </FormGroup>
        <FormGroup>
          <Label>Time Scheduled</Label>
          <Col sm={10}>
            <Input
              type="time"
              min="09:00" max="15:00"
              value={selectedTime}
              onChange={e => setSelectedTime(e.target.value)}
            />
          </Col>
        </FormGroup>
        <FormGroup>
          <Label>Price</Label>
          <Col sm={10}>
            <Input
              type="number"
              step=".01"
              min="0"
              value={selectedPrice}
              onChange={e => setSelectedPrice(parseFloat(e.target.value))}

            />
          </Col>

        </FormGroup>
        <FormGroup>
          <Label for="repertoireSelect">
            Repertoire
          </Label>
          <Col sm={10}>
            <Input
              id="repertoireSelect"
              type="select"
              onChange={handleRepertoireChange}>
              <option value="0">Choose a repertoire</option>
              {repertoires.map(r => (
                <option key={r.id} value={r.id}>{r.title.slice(0, 50)}</option>
              ))}
            </Input>
          </Col>
        </FormGroup><div className="lesson-repertoire-container">
          {selectedRepertoires.length > 0 ?
            selectedRepertoires.map(sr => (
              <div key={sr.id} className="lesson-repertoire">

                <img
                  
                  className="cover"
                  src={sr.image}
                  alt={`Cover of ${sr.title}`}
                  title={sr.title}
                />
                <Button 
                  color="secondary" 
                  size="sm"
                  onClick={() => (
                    setSelectedRepertoires((prevRepertoires) => prevRepertoires.filter((r) => r.id !== sr.id))
                  )}
                  >Remove</Button>
              </div>

            ))
            :
            ""} </div>
      </Form>
      <Button color="primary" onClick={e => handleAddLessonBtn(e)}>Add Lesson</Button>

    </div>
  )
}