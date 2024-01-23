import { Form, useSubmit } from "react-router-dom"
import { Button, FormGroup, Input, Label } from "reactstrap"

export const StudentForm = ({ student, setStudent }) => {

  const useSubmit = (e) => {
    e.preventDefault()
    console.log("Submit button pressed")
  }

  return (
    <div className="student-form-container">
      <form>
          <label for="fname">First Name:</label>
          <Input type="text" id="fname"/>

          
      </form>
      <Button onClick={useSubmit}>Submit</Button>
    </div>
  )
}