import { useEffect, useState } from "react"
import { Button, Form, FormGroup, Input, Label } from "reactstrap"
import { addRepertoire } from "../../managers/repertoireManager"
import { useNavigate } from "react-router-dom"
import { getGoogleBookData } from "../../managers/barcodeServices"
import { BarcodeScanner } from "../scanner/BarcodeScanner"

export const AddRepertoire = () => {
  const [titleInput, setTitleInput] = useState("")
  const [authorInput, setAuthorInput] = useState("")
  const [imageInput, setImageInput] = useState("")
  const [barcode, setBarcode] = useState(0)
  const [googleBook, setGoogleBook] = useState([])
  const [showScanner, setShowScanner] = useState(false)

  const navigate = useNavigate()

  useEffect(() => {
    return () => {
      // Cleanup function to close the scanner when component unmounts
      setShowScanner(false);
    };
  }, []);

  useEffect(() => {
    if (barcode) {
      getGoogleBookData(barcode).then(data => {
        if(data?.items && data.items.length > 0) {
          setGoogleBook(data?.items[0])
        } else {
          console.error("No items were found in the Google Book data.")
        }
      })
    }
  }, [barcode])

  useEffect(() => {
    if (googleBook) {
      try {
        const volumeInfo = googleBook.volumeInfo || {}
        const authors = volumeInfo.authors || []
        const categories = volumeInfo.categories || []
        const imageLinks = volumeInfo.imageLinks || {}
  
        if (!volumeInfo.title || authors.length === 0 || categories.length === 0 || !imageLinks.thumbnail) {
          throw new Error('Incomplete Google Book data: Missing required fields')
        }
        
        setTitleInput(googleBook?.volumeInfo?.title)
        setAuthorInput(googleBook?.volumeInfo?.authors[0])
        setImageInput(googleBook?.volumeInfo?.imageLinks?.thumbnail)
  
      } catch (error) {
        console.error(error)
      }

      }
  }, [googleBook])


  const handleUseBarcodeScannerBtn = () => {
    setShowScanner(!showScanner)
  }


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
      {showScanner && <BarcodeScanner setBarcode={setBarcode} showScanner={showScanner} />}
      {showScanner ?
          <Button className="barcode-scanner-btn" variant="secondary" onClick={handleUseBarcodeScannerBtn}>Close Barcode Scanner</Button>
          :
          <Button className="barcode-scanner-btn" variant="secondary" onClick={handleUseBarcodeScannerBtn}>Use Barcode Scanner</Button>
        }
      <Button color="primary" onClick={handleAddRepertoireBtn}>Add Repertoire</Button>
    </div>
  )
}