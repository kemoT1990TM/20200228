<template>
  <div>
    <h1></h1>
    <v-form ref="form" v-model="valid" lazy-validation>
      <v-text-field v-model="email" :rules="emailRules" label="E-mail" required></v-text-field>

      <v-text-field
        v-model="description"
        :counter="512"
        :rules="descriptionRules"
        label="Description"
        required
      ></v-text-field>

      <v-btn :disabled="!valid" color="success" @click="send">Send Ticket</v-btn>
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
    valid: true,
    description: "",
    descriptionRules: [
      v => !!v || "Name is required",
      v =>
        (v && v.length <= 512) || "Description must be less than 512 characters"
    ],
    email: "",
    emailRules: [
      v => !!v || "E-mail is required",
      v => /.+@.+/.test(v) || "E-mail must be valid"
    ],
    // select: null,
    // items: ["Item 1", "Item 2", "Item 3", "Item 4"],
    checkbox: false,
    dialog: false,
    snackbar: false,
    color: "",
    timeout: 5000,
    text: "Hello"
  }),

  methods: {
    validate() {
      if (this.$refs.form.validate()) {
        this.snackbar = true;
      }
    },
    reset() {
      this.$refs.form.reset();
    },
    resetValidation() {
      this.$refs.form.resetValidation();
    },
    send() {
      this.dialog = true;
      //   body[description] = this.description;
      //   body.email = this.email;
      axios
        .post(Vue.prototype.$url + "/api/Ticket", {
          email: this.email,
          description: this.description
        })
        .then(response => {
          console.log(response);
          this.dialog = false;
          this.color = "success";
          this.snackbar = true;
          this.text = "Succes";
          var ticketId = response.data.Id;
          console.log(ticketId);
          this.$router.push({
            name: "TicketwithID",
            params: { id: ticketId }
          });
        })
        .catch(error => {
          console.log(error);
          this.dialog = false;
          this.color = "error";
          this.snackbar = true;
          this.text = "Error check console to see log";
        });
    }
  },
  watch: {
    dialog(val) {
      if (!val) return;

      //setTimeout(() => (this.dialog = false), 4000);
    }
  }
};
</script>