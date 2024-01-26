import { useState } from "react"
import { Button, Form, FormGroup, Input, Label } from "reactstrap"
import { addRepertoire } from "../../managers/repertoireManager"
import { useNavigate } from "react-router-dom"

export const AddRepertoire = () => {
  const [titleInput, setTitleInput] = useState("")
  const [authorInput, setAuthorInput] = useState("")
  const [imageInput, setImageInput] = useState("")

  const navigate = useNavigate()

  const handleAddRepertoireBtn = (e) => {
    e.preventDefault()
    
    const repertoireToAdd = {
      title: titleInput,
      author: authorInput,
      image: imageInput
    }
    addRepertoire(repertoireToAdd).then(() => navigate("/repertoire"))
  }

  return (
    <div className="container">
      <h2>Add Repertoire</h2>
      <div className="add-repertoire-container">
        <Form className="new-repertoire-form">
          <FormGroup >
            <Label>Title</Label>
            <Input
              type="text"
              value={titleInput}
              onChange={(e) => {
                setTitleInput(e.target.value)
              }}
            />
          </FormGroup>
          <FormGroup>
            <Label>Author</Label>
            <Input
              type="text"
              value={authorInput}
              onChange={(e) => {
                setAuthorInput(e.target.value)
              }}
            />
          </FormGroup>
          <FormGroup>
            <Label>Image</Label>
            <Input
              type="text"
              value={imageInput}
              onChange={(e) => {
                setImageInput(e.target.value)
              }}
            />
          </FormGroup>
        </Form>
        <img className="add-image-cover" src={imageInput} />
      </div>
      <Button color="primary" onClick={handleAddRepertoireBtn}>Add Repertoire</Button>
    </div>
  )
}