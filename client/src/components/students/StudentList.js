import { useEffect, useState } from "react"
import { getStudents } from "../../managers/studentManager"
import { Button, Table } from "reactstrap"
import "./Student.css"
import { formatCurrency } from "../utils/formatCurrency"

export const StudentList = () => {
  const [students, setStudents] = useState([])

  const getAndSetStudents = () => {
    getStudents().then(arr => setStudents(arr))
  }

  useEffect(() => {
    getAndSetStudents()
  }, [])

  return (
    <div className="container">
      <h2>Students</h2>
      <Button className="add-student-btn" color="primary">Add New Student</Button>
      <Table>
        <thead>
          <tr>
            <th>Student Name</th>
            <th>Grade</th>
            <th>Address</th>
            <th>Contact Info</th>
            <th>Parent Name</th>
            <th>Parent Contact Info</th>
            <th>Balance</th>
          </tr>
        </thead>
        <tbody>
          {students.map(s =>
            (
              <tr key={s.id}>
                <td style={{ color: s.isActive ? "black" : "gray"}}>{s.userProfile.firstName} {s.userProfile.lastName}</td>
                <td>{s.grade}</td>
                <td>{s.userProfile.address}</td>
                <td className="contact-info"><div>{s.userProfile.email}</div>{s.phone}</td>
                <td>{s.parentName}</td>
                <td><div>{s.parentEmail}</div>{s.parentPhone}</td>
                <td>{formatCurrency(s.balance)}</td>
              </tr>
            ))}
        </tbody>
      </Table>
    </div>
  )
}