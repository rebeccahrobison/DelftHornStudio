import { useEffect, useState } from "react"
import { deleteLesson, getLessonById, updateLesson } from "../../managers/lessonManager"
import { useNavigate, useParams } from "react-router-dom"
import { formatDate } from "../utils/formatDate"
import { Button, Col, FormGroup, Input, Table } from "reactstrap"
import { getRepertoires } from "../../managers/repertoireManager"
import { formatCurrency } from "../utils/formatCurrency"

export const LessonDetails = ({ loggedInUser }) => {
  const [lesson, setLesson] = useState({
    isCompleted: false,
    price: 0,
    isPaid: false,
    lessonRepertoires: []
  })
  const [repertoires, setRepertoires] = useState([])
  const [selectedRepertoires, setSelectedRepertoires] = useState([])

  const { id } = useParams()
  const navigate = useNavigate()

  useEffect(() => {
    getLessonById(id).then(obj => setLesson(obj))
    getRepertoires().then(arr => setRepertoires(arr))
  }, [id])

  useEffect(() => {
    if (lesson.lessonRepertoires && repertoires.length > 0) {
      const initialRepertoireIds = lesson.lessonRepertoires.map(lr => lr.repertoireId);
      const initialRepertoires = repertoires.filter(r => initialRepertoireIds.includes(r.id));
      setSelectedRepertoires(initialRepertoires);
    }
  }, [lesson.lessonRepertoires, repertoires]);

  const handleRepertoireChange = (e) => {
    const selectedRepertoireId = e.target.value
    const selectedRepertoire = repertoires.find(r => r.id === parseInt(selectedRepertoireId))
    if (selectedRepertoire) {
      // Setting selectedRepertoires
      const updatedSelectedRepertoires = [...selectedRepertoires, selectedRepertoire];
      setSelectedRepertoires(updatedSelectedRepertoires);

      const updatedLessonRepertoires = [...lesson.lessonRepertoires, { repertoireId: selectedRepertoire.id }]
      setLesson(prevLesson => ({
        ...prevLesson,
        lessonRepertoires: updatedLessonRepertoires
      }))
    }
  }

  const handleCancelLessonBtn = (e) => {
    e.preventDefault()

    deleteLesson(lesson.id).then(() => navigate("/lessons"))
  }

  const handleUpdateLessonBtn = (e) => {
    e.preventDefault()

    updateLesson(lesson).then(() => navigate("/lessons"));
  }


  return (
    <div className="container">
      <h2>Lesson Details</h2>
      <Table className="details-container">
        <tbody>
          <tr>
            <th scope="row">Student</th>
            <td>{lesson.student?.userProfile?.firstName} {lesson.student?.userProfile?.lastName}</td>
          </tr>
          <tr>
            <th scope="row">Date Scheduled</th>
            <td>{lesson.dateScheduled && formatDate(lesson?.dateScheduled)}</td>
          </tr>
          <tr>
            <th scope="row">Price</th>
            {loggedInUser.roles.includes("Admin") ? (
              <td>
                <FormGroup>
                  <Input
                    type="number"
                    step=".01"
                    min="0"
                    value={lesson.price}
                    onChange={(e) => {
                      const stateCopy = { ...lesson }
                      stateCopy.price = parseFloat(e.target.value)
                      setLesson(stateCopy)
                    }} />
                </FormGroup>
              </td>
            ) : (
              <td>{formatCurrency(lesson?.price)}</td>
            )}

          </tr>
          <tr>
            <th scope="row">Paid</th>
            {loggedInUser.roles.includes("Admin") ? (
              <td>
                <FormGroup switch className="detail-info">
                  <Input
                    type="switch"
                    checked={lesson.isPaid}
                    value={lesson.isPaid}
                    onChange={(e) => {
                      const stateCopy = { ...lesson }
                      stateCopy.isPaid = e.target.checked
                      setLesson(stateCopy)
                    }}
                  />
                </FormGroup></td>
            ) : (
              <td>{lesson.isPaid ? "Yes" : "No"}</td>
            )}

          </tr>
          <tr>
            <th scope="row">Completed</th>
            {loggedInUser.roles.includes("Admin") ? (
              <td>
                {lesson && (
                  <FormGroup switch className="detail-info">
                    <Input
                      type="switch"
                      checked={lesson.isCompleted}
                      value={lesson.isCompleted}
                      onChange={(e) => {
                        const stateCopy = { ...lesson }
                        stateCopy.isCompleted = e.target.checked
                        setLesson(stateCopy)
                      }}
                    />
                  </FormGroup>
                )}
              </td>
            ) : (
              <td>{lesson.isCompleted ? "Yes" : "No"}</td>
            )}

          </tr>
          <tr>
            <th scope="row">Repertoire</th>
            {loggedInUser.roles.includes("Admin") ? (
              <td>
                <FormGroup>
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
                </FormGroup>
                <div className="lesson-repertoire-container">
                  {selectedRepertoires.length > 0 &&
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
                          onClick={() => {
                            setSelectedRepertoires(prevRepertoires => prevRepertoires.filter(r => r.id !== sr.id));
                            const updatedLessonRepertoires = selectedRepertoires
                              .filter(r => r.id !== sr.id)
                              .map(sr => ({ repertoireId: sr.id }));
                            setLesson(prevLesson => ({
                              ...prevLesson,
                              lessonRepertoires: updatedLessonRepertoires
                            }));
                          }}
                        >Remove</Button>
                      </div>
                    ))}
                </div>
              </td>
            ) : (
              <td>
                <div className="lesson-repertoire-container">
                  {selectedRepertoires.length > 0 ?
                    selectedRepertoires.map(sr => (
                      <div key={sr.id} className="lesson-repertoire">
                        <img
                          className="cover"
                          src={sr.image}
                          alt={`Cover of ${sr.title}`}
                          title={sr.title}
                        />
                      </div>
                    )) : 
                    <div style={{alignSelf:"start" }}>--</div>
                    }
                </div>
              </td>
            )}
          </tr>
        </tbody>
      </Table>
      
      {loggedInUser.roles.includes("Admin") &&
        <div>
          {lesson.isCompleted ? "" : <Button color="secondary" onClick={e => handleCancelLessonBtn(e)}>Cancel Lesson</Button>}
          <Button color="primary" className="update-lesson-btn" onClick={e => handleUpdateLessonBtn(e)}>Update Lesson</Button>
        </div>
      }
    </div>
  )
}