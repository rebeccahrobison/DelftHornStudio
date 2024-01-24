const _apiUrl = "/api/repertoire";

export const getRepertoires = () => {
  return fetch(_apiUrl).then(res => res.json())
}