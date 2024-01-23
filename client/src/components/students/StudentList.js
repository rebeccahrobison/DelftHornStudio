import { useEffect, useState } from "react"
import { getStudents } from "../../managers/studentManager"
import { Button, Table } from "reactstrap"
import 'bootstrap/dist/css/bootstrap.min.css';
import "./Student.css"
import { formatCurrency } from "../utils/formatCurrency"
import { Link, useNavigate } from "react-router-dom";

export const StudentList = () => {
  const [students, setStudents] = useState([])

  const navigate = useNavigate()

  const getAndSetStudents = () => {
    getStudents().then(arr => setStudents(arr))
  }

  useEffect(() => {
    getAndSetStudents()
  }, [])

  const handleAddNewStudentBtn = (e) => {
    e.preventDefault()
    // console.log("button clicked")
    navigate("student/add")
  }

  return (
    <div className="container">
      <h2>Students</h2>
      {/* <Button 
        className="add-student-btn" 
        color="primary"
        onClick={handleAddNewStudentBtn}
        >Add New Student
      </Button> */}
      <Table className="table-container">
        <thead className="table-header">
          <tr>
            <th>Student Name</th>
            <th>Grade</th>
            <th>Address</th>
            <th>Contact Info</th>
            <th>Parent Name</th>
            <th>Parent Contact Info</th>
            <th>Balance</th>
            <th>Active</th>
          </tr>
        </thead>
        <tbody className="table-body">
          {students.map(s =>
            (
              <tr key={s.id}>
                <td><Link to={`student/${s.id}`}>{s.userProfile.firstName} {s.userProfile.lastName}</Link></td>
                <td>{s.grade}</td>
                <td>{s.userProfile.address}</td>
                <td className="contact-info"><div>{s.userProfile.email}</div>{s.phone}</td>
                <td>{s.parentName}</td>
                <td><div>{s.parentEmail}</div>{s.parentPhone}</td>
                <td>{formatCurrency(s.balance)}</td>
                <td>{s.isActive ? "Yes" : "No"}</td>
              </tr>
            ))}
        </tbody>
      </Table>
    </div>
  )
}