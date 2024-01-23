const _apiUrl = "/api/lesson"

export const getLessons = () => {
  return fetch(_apiUrl).then(res => res.json())
}