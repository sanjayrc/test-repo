import axios from 'axios'

const client = axios.create({
  baseURL: 'https://localhost:44332/customers',
  json: true
})

export default {
  async execute (method, resource, data) {
    return client({
      method,
      url: resource,
      data
    }).then(req => {
      return req.data
    })
  },
  getActiveCustomers () {
    return this.execute('get', '/')
  },
  getAllCustomers () {
    return this.execute('get', `/?includeAll=true`)
  },
  getCustomer (id) {
    return this.execute('get', `/${id}`)
  },
  createCustomer (data) {
    return this.execute('post', '/', data)
  },
  updateCustomer (id, data) {
    return this.execute('put', `/${id}`, data)
  },
  deleteCustomer (id) {
    return this.execute('delete', `/${id}`)
  }
}
