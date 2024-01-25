import { useEffect, useState } from "react"
import { getRepertoires } from "../../managers/repertoireManager"
import "./Repertoire.css"

export const RepertoireList = () => {
  const [repertoires, setRepertoires] = useState([])

  const getAndSetRepertoires = () => {
    getRepertoires().then(arr => setRepertoires(arr))
  }

  useEffect(() => {
    getAndSetRepertoires()
  }, [])

  return (
    <div className="container">
      <h2>Repertoire</h2>
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