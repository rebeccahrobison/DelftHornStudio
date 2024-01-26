import { useEffect, useState } from "react"
import { getRepertoires } from "../../managers/repertoireManager"
import "./Repertoire.css"
import { Button } from "reactstrap"
import { useNavigate } from "react-router-dom"

export const RepertoireList = () => {
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

  return (
    <div className="container">
      <h2>Studio Repertoire</h2>
      <Button className="add-repertoire-btn" onClick={handleAddRepertoireBtn}>Add New Repertoire</Button>
      <div className="repertoire-list">
        {repertoires.map(r => {
          return (
            <div key={r.id} className="repertoire">
              <div className="repertoire-info cover">
                <img src={r.image} />
              </div>
              <div className="repertoire-info-container">
                <div className="repertoire-info title">{r.title}</div>
                <div className="repertoire-info author">{r.author}</div>
              </div>
            </div>
          )
        })}
      </div>
    </div>
  )
}