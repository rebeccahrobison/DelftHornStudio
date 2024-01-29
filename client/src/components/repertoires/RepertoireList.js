import { useEffect, useState } from "react"
import { deleteRepertoire, getRepertoires } from "../../managers/repertoireManager"
import "./Repertoire.css"
import { Button } from "reactstrap"
import { useNavigate } from "react-router-dom"

export const RepertoireList = ({ loggedInUser }) => {
  const [repertoires, setRepertoires] = useState([])

  const navigate = useNavigate()

  const getAndSetRepertoires = () => {
    getRepertoires().then(arr => setRepertoires(arr))
  }

  useEffect(() => {
    getAndSetRepertoires()
  }, [])

  const handleAddRepertoireBtn = (e) => {
    e.preventDefault()
    navigate("add")
  }

  const handleDeleteBtn = (e, id) => {
    e.preventDefault()
    console.log("id", id)
    deleteRepertoire(id).then(() => getAndSetRepertoires())
  }

  return (
    <div className="container">
      <h2>Studio Repertoire</h2>
      {loggedInUser.roles.includes("Admin") && <Button className="add-repertoire-btn" onClick={handleAddRepertoireBtn}>Add New Repertoire</Button>}
      <div className="repertoire-list">
        {repertoires?.map(r => {
          return (
            <div key={r.id} className="repertoire">
              <div className="repertoire-info cover">
                <img src={r?.image} alt={`Cover of ${r.title} book`}/>
              </div>
              <div className="repertoire-info-container">
                <div className="repertoire-info title">{r?.title}</div>
                <div className="repertoire-info author">{r?.author}</div>
              </div>
              {loggedInUser.roles.includes("Admin") && (
                <Button size="sm" className="repertoire-delete-btn" onClick={e => handleDeleteBtn(e, r.id)}>Delete</Button>
              )}
            </div>
          )
        })}
      </div>
    </div>
  )
}