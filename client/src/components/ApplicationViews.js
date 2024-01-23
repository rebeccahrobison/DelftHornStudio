import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { StudentList } from "./students/StudentList";
import 'bootstrap/dist/css/bootstrap.min.css';
import "./ApplicationViews.css"
import { StudentDetails } from "./students/StudentDetails";
import { EditStudent } from "./students/EditStudent";
import { LessonList } from "./lessons/LessonList";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <StudentList />
            </AuthorizedRoute>
          }
        />
        <Route path="student/:id"
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <StudentDetails />
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

        <Route path="lessons"
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <LessonList />
            </AuthorizedRoute>
          }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
