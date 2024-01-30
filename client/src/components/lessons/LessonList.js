import { useEffect, useState } from "react"
import { getLessons } from "../../managers/lessonManager"
import { Button, FormGroup, Input, Table } from "reactstrap"
import { formatDate } from "../utils/formatDate"
import { formatCurrency } from "../utils/formatCurrency"
import "./Lesson.css"
import { Link, useNavigate } from "react-router-dom"

export const LessonList = () => {
  const [lessons, setLessons] = useState([])
  const [sortedLessons, setSortedLessons] = useState([])

  const navigate = useNavigate()

  const getAndSetLessons = () => {
    getLessons().then(arr => {
      setLessons(arr)
      setSortedLessons(arr)
    })
  }

  useEffect(() => {
    getAndSetLessons()
  }, [])

  const handleAddNewLessonBtn = (e) => {
    e.preventDefault()

    navigate("add")
  }

  const handleSortSelectChange = (e) => {
    if (e.target.value === "0") {
      setSortedLessons(lessons)
    } else if (e.target.value === "1") {
      const lessonsSortedByLastName = [...lessons].sort((a, b) => {
        const lastNameA = a.student.userProfile.lastName.toUpperCase()
        const lastNameB = b.student.userProfile.lastName.toUpperCase()
        if (lastNameA < lastNameB) {
          return -1
        }
        if (lastNameA > lastNameB) {
          return 1
        }
        return 0
      })
      setSortedLessons(lessonsSortedByLastName)
    } else if (e.target.value === "2") {
      const lessonsSortedByCompletion = [...lessons].sort((a, b) => {
        if (a.isCompleted && !b.isCompleted) {
          return -1
        } else if (!a.isCompleted && b.isCompleted) {
          return 1
        } else {
          const lastNameA = a.student.userProfile.lastName.toUpperCase()
          const lastNameB = b.student.userProfile.lastName.toUpperCase()
          if (lastNameA < lastNameB) {
            return -1
          } else if (lastNameA > lastNameB) {
            return 1
          } else {
            return 0
          }
        }
      })
      setSortedLessons(lessonsSortedByCompletion)
    } else if (e.target.value === "3") {
      const lessonsSortedByPaid = [...lessons].sort((a, b) => {
        if (a.isPaid && !b.isPaid) {
          return -1
        } else if (!a.isPaid && b.isPaid) {
          return 1
        } else {
          const lastNameA = a.student.userProfile.lastName.toUpperCase()
          const lastNameB = b.student.userProfile.lastName.toUpperCase()
          if (lastNameA < lastNameB) {
            return -1
          } else if (lastNameA > lastNameB) {
            return 1
          } else {
            return 0
          }
        }
      })
      setSortedLessons(lessonsSortedByPaid)
    }
  }

  return (
    <div className="container">
      <h2>Lessons</h2>
      <div className="lessons-header">
        <FormGroup>
          <Input type="select" onChange={handleSortSelectChange}>
            <option value="0">Sort lessons by...</option>
            <option value="1">Student Last Name</option>
            <option value="2">Completed</option>
            <option value="3">Paid</option>
          </Input>
        </FormGroup>
        <Button
          className="add-lesson-btn"
          color="primary"
          onClick={handleAddNewLessonBtn}
        >Add New Lesson
        </Button>
      </div>

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
          {sortedLessons?.map(l => (
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