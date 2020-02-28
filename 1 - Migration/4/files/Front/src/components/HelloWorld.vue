<template>
  <v-container>
    <v-layout text-center wrap>
      <v-flex mb-4>
        <h1 class="display-2 font-weight-bold mb-3">Welcome to Tikect service</h1>
        <p class="subheading font-weight-regular">
          <!-- For help and collaboration with other Vuetify developers, -->
        </p>
        <v-form ref="form">
          <v-text-field v-model="userApi" label="https://localhost:5001">{{api}}</v-text-field>
          <v-btn color="success" @click="ADDURL()">Update Api</v-btn>
        </v-form>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import Vue from "vue";

export default {
  data: () => ({
    userApi: Vue.prototype.$url,
    api: Vue.prototype.$url
  }),

  methods: {
    ADDURL() {
      Vue.prototype.$url = this.userApi;
      localStorage.$url = this.userApi;
      console.log(Vue.prototype.$url);
    }
  }
};
</script>
