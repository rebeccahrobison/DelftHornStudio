const _apiUrl = "/api/student";

export const getStudents = () => {
  return fetch(_apiUrl).then(res => res.json())
}