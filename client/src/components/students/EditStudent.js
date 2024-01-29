import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { Button, FormGroup, Input, Label } from "reactstrap";
import { updateStudent } from "../../managers/studentManager";

export const EditStudent = ({ loggedInUser }) => {
  const [student, setStudent] = useState({
    grade: "",
    address: "",
    parentName: "",
    parentEmail: "",
    parentAddress: "",
    parentPhone: "",
    phone: "",
    isActive: true,
    userProfile: {
      firstName: "",
      lastName: "",
      address: "",
      identityUser: {
        email: ""
      }
    }
  })

  const navigate = useNavigate()

  const location = useLocation()
  const studentToEdit = location.state?.student


  useEffect(() => {
    if (JSON.stringify(student) !== JSON.stringify(studentToEdit)) {
      setStudent(studentToEdit);
    }
  }, [studentToEdit])

  const handleUpdateStudentBtn = (e) => {
    e.preventDefault()
    if (loggedInUser.roles.includes("Admin")) {
      updateStudent(student).then(navigate(`/student/${student.id}`))
    } else {
      updateStudent(student).then(navigate(`/`))
    }
  }

  return (
    <div className="container">
      <h2 className="edit-student-header">Edit Student Details</h2>
      <FormGroup className="edit-student-form-group">
        <Label>Student First Name</Label>
        <Input
          type="text"
          value={student.userProfile?.firstName}
          onChange={(e) => {
            const stateCopy = { ...student }
            stateCopy.userProfile.firstName = e.target.value
            setStudent(stateCopy)
          }}
        />
      </FormGroup>
      <FormGroup className="edit-student-form-group">
        <Label>Student Last Name</Label>
        <Input
          type="text"
          value={student.userProfile?.lastName}
          onChange={(e) => {
            const stateCopy = { ...student }
            stateCopy.userProfile.lastName = e.target.value
            setStudent(stateCopy)
          }}
        />
      </FormGroup>
      <FormGroup className="edit-student-form-group">
        <Label>Grade</Label>
        <Input
          type="text"
          value={student.grade}
          onChange={(e) => {
            const stateCopy = { ...student }
            stateCopy.grade = parseInt(e.target.value)
            setStudent(stateCopy)
          }}
        />
      </FormGroup>
      <FormGroup className="edit-student-form-group">
        <Label>Address</Label>
        <Input
          type="text"
          value={student.userProfile?.address}
          onChange={(e) => {
            const stateCopy = { ...student }
            stateCopy.userProfile.address = e.target.value
            setStudent(stateCopy)
          }}
        />
      </FormGroup>
      <FormGroup className="edit-student-form-group">
        <Label>Email</Label>
        <Input
          type="text"
          value={student.userProfile?.identityUser.email}
          onChange={(e) => {
            const stateCopy = { ...student }
            stateCopy.userProfile.identityUser.email = e.target.value
            setStudent(stateCopy)
          }}
        />
      </FormGroup>
      <FormGroup className="edit-student-form-group">
        <Label>Phone</Label>
        <Input
          type="text"
          value={student.phone}
          onChange={(e) => {
            const stateCopy = { ...student }
            stateCopy.phone = e.target.value
            setStudent(stateCopy)
          }}
        />
      </FormGroup>
      <FormGroup className="edit-student-form-group">
        <Label>Parent Name</Label>
        <Input
          type="text"
          value={student.parentName}
          onChange={(e) => {
            const stateCopy = { ...student }
            stateCopy.parentName = e.target.value
            setStudent(stateCopy)
          }}
        />
      </FormGroup>
      <FormGroup className="edit-student-form-group">
        <Label>Parent Address</Label>
        <Input
          type="text"
          value={student.parentAddress}
          onChange={(e) => {
            const stateCopy = { ...student }
            stateCopy.parentAddress = e.target.value
            setStudent(stateCopy)
          }}
        />
      </FormGroup>
      <FormGroup className="edit-student-form-group">
        <Label>Parent Email</Label>
        <Input
          type="text"
          value={student.parentEmail}
          onChange={(e) => {
            const stateCopy = { ...student }
            stateCopy.parentEmail = e.target.value
            setStudent(stateCopy)
          }}
        />
      </FormGroup>
      <FormGroup className="edit-student-form-group">
        <Label>Parent Phone</Label>
        <Input
          type="text"
          value={student.parentPhone}
          onChange={(e) => {
            const stateCopy = { ...student }
            stateCopy.parentPhone = e.target.value
            setStudent(stateCopy)
          }}
        />
      </FormGroup>
      {loggedInUser.roles.includes("Admin") && 
        <FormGroup switch>
        <Label check>Active</Label>
          <Input
            type="switch"
            checked={student.isActive}
            onChange={(e) => {
              const stateCopy = {...student}
              stateCopy.isActive = e.target.checked
              setStudent(stateCopy)
            }}
          />
          
        </FormGroup>
      }

      <Button color="primary" className="update-student-btn" onClick={e => handleUpdateStudentBtn(e)}>Update Student</Button>
    </div>
  )
}