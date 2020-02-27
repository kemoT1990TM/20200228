<template>
  <div>
    <h1></h1>
    <v-form ref="form">
      <h1>Email: {{email}}</h1>
      <h2>Description: {{description}}</h2>
      <h2>Status: {{status}}</h2>
      <h1>FILES</h1>
      <ul id="example-1">
        <li v-for="file in files">
          {{ file.FileName }}
          <a :href="file.WebLocation">Download</a>
        </li>
      </ul>
      <h1>Comments</h1>
      <ul id="example-1">
        <li v-for="comment in comments">
          User : {{ comment.User }}
          <br />
          Message : {{ comment.Message }}
        </li>
      </ul>

      <v-dialog v-model="dialog" hide-overlay persistent width="300">
        <v-card color="primary" dark>
          <v-card-text>
            Please stand by
            <v-progress-linear indeterminate color="white" class="mb-0"></v-progress-linear>
          </v-card-text>
        </v-card>
      </v-dialog>
    </v-form>
    <v-snackbar v-model="snackbar" :color="color" :timeout="timeout">
      {{ text }}
      <v-btn dark text @click="snackbar = false">Close</v-btn>
    </v-snackbar>
  </div>
</template>


<script>
import Vue from "vue";

export default {
  data: () => ({
    description: "Description",
    email: "E-mail",
    status: "",
    comments: [],
    files: [],
    // select: null,
    // items: ["Item 1", "Item 2", "Item 3", "Item 4"],
    checkbox: false,
    dialog: true,
    snackbar: false,
    color: "",
    timeout: 5000,
    text: "Hello",
    ticketId: "",
    api: Vue.prototype.$url
  }),

  created() {
    this.initialize();
  },

  methods: {
    initialize() {
      this.ticketId = this.$route.params.id;
      axios
        .get(Vue.prototype.$url + "/api/Ticket/" + this.ticketId)
        .then(response => {
          console.log(response.data);
          console.log(response.data.Email);
          this.email = response.data.Email;
          this.description = response.data.Description;
          this.status = response.data.TicketStatus;
          this.comments = response.data.Comments;
          this.files = response.data.Files;
          this.dialog = false;
        });
    }
  },
  watch: {
    dialog(val) {
      if (!val) return;
    }
  }
};
</script>