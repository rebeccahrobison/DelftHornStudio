import { Route, Routes } from "react-router-dom";
import Login from "./auth/Login";
import Register from "./auth/Register";
import 'bootstrap/dist/css/bootstrap.min.css';
import "./ApplicationViews.css"
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import { StudentDetails } from "./students/StudentDetails";
import { EditStudent } from "./students/EditStudent";
import { LessonDetails } from "./lessons/LessonDetails";
import { RepertoireList } from "./repertoires/RepertoireList";
import { StudentList } from "./students/StudentList";
import { LessonList } from "./lessons/LessonList";
import { AddLesson } from "./lessons/AddLesson";
import { AddRepertoire } from "./repertoires/AddRepertoire";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {

  const views = () => {
    if (loggedInUser?.roles.includes("Admin")) {
      return (
        <Route path="/">
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
                <StudentDetails loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
          <Route path="student/:id/edit"
            element={
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <EditStudent loggedInUser={loggedInUser} />
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
                  <LessonDetails loggedInUser={loggedInUser} />
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
      )
    } else if (loggedInUser) {
      return (
        <Route path="/">
          <Route index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <StudentDetails loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            } />
          <Route path="edit"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <EditStudent loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            } />
          <Route path="lessons/:id"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <LessonDetails loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            } />
          <Route path="repertoire"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <RepertoireList loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            } />
        </Route>
      )
    } else {
      return (<></>)
    }
  }

  return (

    <Routes>
      {views()}

      <Route
        path="login"
        element={<Login setLoggedInUser={setLoggedInUser} />}
      />
      <Route
        path="register"
        element={<Register setLoggedInUser={setLoggedInUser} />}
      />

      <Route path="*" element={<p style={{ backgroundColor: "white" }}>Whoops, nothing here...</p>} />
    </Routes>

  );
}




{/* 
        <Route
          index
          element={
            {loggedInUser?.roles.includes("Admin") && (
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <StudentList />
              </AuthorizedRoute>
            )}
          {loggedInUser.roles === null && (
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <RepertoireList />
            </AuthorizedRoute>
            // <Navigate to={`/student/${loggedInUser.student?.id}`} state={{ loggedInUser }} />
          )
          }
        }
        /> */}


{/* <Route
          index
          element={
            <Routes>

              <Route path="" element={

                <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                  <StudentList loggedInUser={loggedInUser} />

                </AuthorizedRoute>
              }
              />
              <Route path="" element={<StudentDetails loggedInUser={loggedInUser} />} />
            </Routes>
          }
        /> */}


{/* {loggedInUser?.roles.includes("Admin") ? (
        <Route index element={
          <AdminViews loggedInUser={loggedInUser} />

        }
        />
      ) : (
        <Route index element={
          <StudentViews loggedInUser={loggedInUser} />
        }
        />
      )
      } */}