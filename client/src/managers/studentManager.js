const _apiUrl = "/api/student";

export const getStudents = () => {
  return fetch(_apiUrl).then(res => res.json())
}

export const getStudentById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then(res => res.json())
}

export const updateStudent = (student) => {
  return fetch(`${_apiUrl}/${student.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(student),
  })
}