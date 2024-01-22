import { useEffect, useState } from "react"
import { getStudentById } from "../../managers/studentManager"
import { useParams } from "react-router-dom"
import { Button, Table } from "reactstrap"
import { formatDate } from "../utils/formatDate"
import { formatCurrency } from "../utils/formatCurrency"

export const StudentDetails = () => {
  const [student, setStudent] = useState({})
  const { id } = useParams()

  useEffect(() => {
    getStudentById(id).then(obj => setStudent(obj))
  }, [id])

  return (
    <div className="container">
      <h2>Student Details</h2>
      <div className="student-info">
        <div className="student-info-table">
          <Table>
            <tbody>
              <tr key={student.id}>
                <th scope="row">Student Name:</th>
                <td>{student.userProfile?.firstName} {student.userProfile?.lastName}</td>
              </tr>
              <tr>
                <th scope="row">Grade:</th>
                <td>{student.grade}</td>
              </tr>
              <tr>
                <th scope="row">Address:</th>
                <td>{student.userProfile?.address}</td>
              </tr>
              <tr>
                <th scope="row">Email:</th>
                <td>{student.userProfile?.email}</td>
              </tr>
              <tr>
                <th scope="row">Phone:</th>
                <td>{student.phone}</td>
              </tr>
              <tr>
                <th scope="row">Parent Name:</th>
                <td>{student.parentName}</td>
              </tr>
              <tr>
                <th scope="row">Parent Email:</th>
                <td>{student.parentEmail}</td>
              </tr>
              <tr>
                <th scope="row">Parent Phone:</th>
                <td>{student.parentPhone}</td>
              </tr>
              <tr>
                <th scope="row">Parent Address:</th>
                <td>{student.parentAddress}</td>
              </tr>
            </tbody>
          </Table>

        </div>

        <div className="student-info-table">
          <Table>
            <thead>
              <tr>
                <th>Lessons</th>
                <th>Balance</th>
              </tr>
            </thead>
            <tbody>
              {student.lessons?.map(l =>
              (
                <tr key={l.id}>
                  <td>{formatDate(l.dateScheduled)}</td>
                  <td style={{ color: !l.isPaid && l.isCompleted ? "red" : "black"}}>{!l.isPaid && l.isCompleted ? formatCurrency(l.price) : formatCurrency(0)}</td>
                </tr>
              ))}
            </tbody>
          </Table>
          <Table>
            <tbody>
              <tr>
                <th scope="row">Total Due:</th>
                <td>{formatCurrency(student.balance)}</td>
              </tr>
            </tbody>
          </Table>
        </div>
      </div>
      <Button className="edit-student-btn" color="primary">Edit Student Information</Button>
    </div>
  )
}