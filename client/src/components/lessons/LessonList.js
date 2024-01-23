import { useEffect, useState } from "react"
import { getLessons } from "../../managers/lessonManager"
import { Button, Table } from "reactstrap"
import { formatDate } from "../utils/formatDate"
import { formatCurrency } from "../utils/formatCurrency"

export const LessonList = () => {
  const [lessons, setLessons] = useState([])

  const getAndSetLessons = () => {
    getLessons().then(arr => setLessons(arr))
  }

  useEffect(() => {
    getAndSetLessons()
  }, [])

  const handleAddNewLessonBtn = (e) => {
    e.preventDefault()
  }

  return (
    <div className="container">
      <h2>Lessons</h2>
            <Button 
        className="add-student-btn" 
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
              <td>{formatDate(l.dateScheduled).split(',').slice(0, 2).join(',')}</td>
              <td>{formatDate(l.dateScheduled).split(',').slice(2).join(',')}</td>
              <td>{l.student.userProfile.firstName} {l.student.userProfile.lastName}</td>
              <td>{l.isCompleted ? "Yes" : "No"}</td>
              <td>{formatCurrency(l.price)}</td>
              <td>{l.isPaid ? "Yes" : "No"}</td>
              <td>
                <ul style={{ listStyleType: 'disc', paddingLeft: '1em' }}>
                {l.lessonRepertoires.map(lr => (
                  <li key={lr.id} title={lr.repertoire.title}>
                    {lr.repertoire.title.length > 35
                    ? `${lr.repertoire.title.slice(0, 35)}...`
                    :lr.repertoire.title}
                  </li>
                ))}
                </ul>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  )
}