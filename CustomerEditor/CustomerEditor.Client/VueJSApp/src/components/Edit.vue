<template>
  <div class="edit">
    <b-container fluid>
      <b-row>
        <b-col lg="4" md="6" sm="8">
          <h2>Update Customer</h2>
        </b-col>
      </b-row>
      <b-row>
        <b-col lg="6" md="8" sm="10">
          <b-form @submit="saveCustomer">
            <b-form-group label="First Name" horizontal>
              <b-form-input type="text" v-model="customer.firstName"></b-form-input>
            </b-form-group>
            <b-form-group label="Last Name" horizontal>
              <b-form-input type="text" v-model="customer.lastName"></b-form-input>
            </b-form-group>
            <b-form-group label="Address" horizontal>
              <b-form-input type="text" v-model="customer.address"></b-form-input>
            </b-form-group>
            <b-form-group label="Active" horizontal>
              <b-form-checkbox v-model="customer.active"></b-form-checkbox>
            </b-form-group>
            <div>
              <b-btn type="submit" variant="success">Save</b-btn>
              <b-btn type="button" @click.prevent="onCancel" >Cancel</b-btn>
            </div>
          </b-form>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
  import api from '@/api'
  export default {
    name: 'edit',
    data () {
      return {
        customer: {}
      }
    },
    created () {
      this.fetchData()
    },
    methods: {
      async fetchData () {
        this.loading = true
        var id = this.$route.params.id
        if (id !== undefined) {
          this.customer = await api.getCustomer(id)
        } else {
          this.customer = {}
        }
        this.loading = false
      },
      onCancel () {
        this.show = false
        this.$router.push({ name: 'Home' })
      },
      async saveCustomer () {
        var id = this.$route.params.id
        await api.updateCustomer(id, this.customer)
        this.$router.push({ name: 'Home' })
      }
    }
  }
</script>

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
  color: #35495E;
  display: inline-block;
  }
</style>
