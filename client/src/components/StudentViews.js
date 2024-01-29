import { Route, Routes } from "react-router-dom"
import { AuthorizedRoute } from "./auth/AuthorizedRoute"
import { StudentDetails } from "./students/StudentDetails"
import { EditStudent } from "./students/EditStudent"

export const StudentViews = ({ loggedInUser }) => {
  return (
    <Routes>
      <Route path="/*">
        <Route index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <StudentDetails loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          } />
        <Route path="edit"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <EditStudent />
            </AuthorizedRoute>
          } />
      </Route>
    </Routes>
  )
}