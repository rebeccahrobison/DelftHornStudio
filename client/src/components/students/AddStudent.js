import { useState } from "react"
import { useNavigate } from "react-router-dom"
import { StudentForm } from "./StudentForm"

export const AddStudent = () => {
  const [student, setStudent] = useState({
    grade: null,
    phone: null,
    parentName: null,
    parentEmail: null,
    parentPhone: null,
    parentAddress: null,
    userProfile: {
      firstName: null,
      lastName: null,
      address: null
    }
  })

  const navigate = useNavigate()

  return (
    <div className="container">
      <h2>Add New Student</h2>

      <StudentForm student={student} setStudent={setStudent} />
    </div>
  )
}