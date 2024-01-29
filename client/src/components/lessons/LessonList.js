import { useEffect, useState } from "react"
import { getLessons } from "../../managers/lessonManager"
import { Button, Table } from "reactstrap"
import { formatDate } from "../utils/formatDate"
import { formatCurrency } from "../utils/formatCurrency"
import "./Lesson.css"
import { Link, useNavigate } from "react-router-dom"

export const LessonList = () => {
  const [lessons, setLessons] = useState([])

  const navigate = useNavigate()

  const getAndSetLessons = () => {
    getLessons().then(arr => setLessons(arr))
  }

  useEffect(() => {
    getAndSetLessons()
  }, [])

  const handleAddNewLessonBtn = (e) => {
    e.preventDefault()

    navigate("add")
  }

  return (
    <div className="container">
      <h2>Lessons</h2>
      <Button
        className="add-lesson-btn"
        color="primary"
        onClick={handleAddNewLessonBtn}
      >Add New Lesson
      </Button>
      <Table>
        <thead>
          <tr>
            <th>Date</th>
            <th>Time</th>
            <th>Student</th>
            <th>Completed</th>
            <th>Price</th>
            <th>Paid</th>
            <th>Repertoire</th>
          </tr>
        </thead>
        <tbody>
          {lessons.map(l => (
            <tr key={l.id}>
              <td><Link to={`${l.id}`}>{formatDate(l.dateScheduled).split(',').slice(0, 2).join(',')}</Link></td>
              <td>{formatDate(l.dateScheduled).split(',').slice(2).join(',')}</td>
              <td>{l.student.userProfile.firstName} {l.student.userProfile.lastName}</td>
              <td>{l.isCompleted ? "Yes" : "No"}</td>
              <td>{formatCurrency(l.price)}</td>
              <td>{l.isPaid ? "Yes" : "No"}</td>
              <td className="lesson-repertoire-container">
                {l.lessonRepertoires.length > 0 ?
                  l.lessonRepertoires.map(lr => (
                    <img 
                      key={lr.id} 
                      className="cover" 
                      src={lr.repertoire.image} 
                      alt={`Cover of ${lr.repertoire.title}`} 
                      title={lr.repertoire.title}
                    />

                  )
                  )
                  : "---"
                }
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  )
}