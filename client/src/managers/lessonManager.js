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

export const getLessonById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
}

export const deleteLesson = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE"
  })
}

export const updateLesson = (lesson) => {
  return fetch(`${_apiUrl}/${lesson.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(lesson),
  });
}