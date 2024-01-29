import { Route, Routes } from "react-router-dom";
import Login from "./auth/Login";
import Register from "./auth/Register";
import 'bootstrap/dist/css/bootstrap.min.css';
import "./ApplicationViews.css"
import { AdminViews } from "./AdminViews";
import { StudentViews } from "./StudentViews";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import { StudentDetails } from "./students/StudentDetails";
import { EditStudent } from "./students/EditStudent";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {

  const views = () => {
    if (loggedInUser?.roles.includes("Admin")) {
      return (
        <Route index element={
          <AdminViews loggedInUser={loggedInUser} />
        } />
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
                <EditStudent loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            } />
        </Route>

        // <Route index element={

        //     // <StudentViews loggedInUser={loggedInUser} />

        //     <Routes>
        //     {/* <Route path="/*"> */}
        //       <Route path="/*">
        //         <Route index 
        //         element={
        //           <AuthorizedRoute loggedInUser={loggedInUser}>
        //             <StudentDetails loggedInUser={loggedInUser} />
        //           </AuthorizedRoute>
        //         } />

        //       </Route>
        //       <Route path="edit"
        //         element={
        //           <AuthorizedRoute loggedInUser={loggedInUser}>
        //             <EditStudent />
        //           </AuthorizedRoute>
        //         } />
        //     {/* </Route> */}
        //   </Routes>

        // } />
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