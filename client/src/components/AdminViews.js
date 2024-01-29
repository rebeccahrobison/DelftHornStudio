import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import { StudentList } from "./students/StudentList";
import 'bootstrap/dist/css/bootstrap.min.css';
import "./ApplicationViews.css"
import { StudentDetails } from "./students/StudentDetails";
import { EditStudent } from "./students/EditStudent";
import { LessonList } from "./lessons/LessonList";
import { AddLesson } from "./lessons/AddLesson";
import { LessonDetails } from "./lessons/LessonDetails";
import { RepertoireList } from "./repertoires/RepertoireList";
import { AddRepertoire } from "./repertoires/AddRepertoire";

export const AdminViews = ({ loggedInUser }) => {
  return (
    <Routes>
      <Route path="/*">
        <Route
          index
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <StudentList />
            </AuthorizedRoute>
          } />
        <Route path="student/:id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <StudentDetails loggedInUser={loggedInUser}/>
            </AuthorizedRoute>
          }
        />
        <Route path="student/:id/edit"
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <EditStudent />
            </AuthorizedRoute>
          }
        />
        <Route path="lessons">
          <Route index
            element={
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <LessonList />
              </AuthorizedRoute>
            } />
          <Route path="add" element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <AddLesson />
            </AuthorizedRoute>
          } />
          <Route path=":id"
            element={
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <LessonDetails />
              </AuthorizedRoute>
            } />
        </Route>

        <Route path="repertoire">
          <Route index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <RepertoireList loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            } />
          <Route path="add"
            element={
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <AddRepertoire />
              </AuthorizedRoute>
            } />
        </Route>
      </Route>
    </Routes>
  )
}