<template>
  <div class="home">
    <b-container fluid>
      <b-row>
        <b-col>
          <h2>Customers List</h2>
        </b-col>
        <b-col align-self="center">
          <div class="float-right">
            <router-link to="Create">Create New Customer</router-link>
          </div>
        </b-col>
      </b-row>
      <b-row>
        <b-col>
          <table class="table table-striped">
            <thead>
              <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Address</th>
                <th>Active</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="customer in customers" :key="customer.id">
                <td>{{ customer.firstName }}</td>
                <td>{{ customer.lastName }}</td>
                <td>{{ customer.address }}</td>
                <td v-if="customer.active == true">Yes</td>
                <td v-else>No</td>
                <td class="text-left">
                  <router-link :to="{path: '/edit/' + customer.id}">Edit</router-link> | 
                  <a href="#" @click.prevent="deleteCustomer(customer.id)">Delete</a>
                </td>
              </tr>
            </tbody>
          </table>
        </b-col>
      </b-row>
      <b-row>
        <b-col>
          <input type="checkbox" id="loadAll" v-model="showAll" @change="loadCustomers">
          <label for="loadAll">Show Inactive Customers</label>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
  import api from '@/api'
  export default {
    name: 'home',
    data () {
      return {
        customers: [],
        showAll: false
      }
    },
    created () {
      this.fetchData()
    },
    methods: {
      async fetchData () {
        this.loading = true
        this.customers = await api.getActiveCustomers()
        this.loading = false
      },
      async deleteCustomer (id) {
        await api.deleteCustomer(id)
        this.fetchData()
      },
      async loadCustomers () {
        if (this.showAll) {
          this.customers = await api.getAllCustomers()
        } else {
          this.customers = await api.getActiveCustomers()
        }
      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
  h1, h2 {
  font-weight: normal;
  padding: 20px 0;
  }

  ul {
  list-style-type: none;
  padding: 0;
  }

  li {
  display: inline-block;
  margin: 0 10px;
  }

  a {
  color: #007bff;
  display: inline-block;
  }
</style>
