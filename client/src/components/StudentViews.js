import { Route, Routes } from "react-router-dom"
import { AuthorizedRoute } from "./auth/AuthorizedRoute"
import { StudentDetails } from "./students/StudentDetails"

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
      </Route>
    </Routes>
  )
}