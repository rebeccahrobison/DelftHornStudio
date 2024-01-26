const _apiUrl = "/api/repertoire";

export const getRepertoires = () => {
  return fetch(_apiUrl).then(res => res.json())
}

export const addRepertoire = (repertoire) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(repertoire),
  }).then((res) => res.json);
}

export const deleteRepertoire = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE"
  })
}