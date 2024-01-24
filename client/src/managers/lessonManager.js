const _apiUrl = "/api/lesson"

export const getLessons = () => {
  return fetch(_apiUrl).then(res => res.json())
}

export const addLesson = (lesson) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(lesson),
  }).then((res) => res.json);
}