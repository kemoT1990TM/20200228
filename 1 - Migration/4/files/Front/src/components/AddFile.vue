<template>
  <div>
    <h1></h1>
    <v-form ref="form" v-model="valid" lazy-validation>
      <label>
        File
        <input type="file" id="file" ref="file" v-on:change="handleFileUpload()" />
      </label>
      <v-btn :disabled="!valid" color="success" @click="send">Add File</v-btn>
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
    message: "",
    // select: null,
    // items: ["Item 1", "Item 2", "Item 3", "Item 4"],
    checkbox: false,
    dialog: false,
    snackbar: false,
    user: "",
    timeout: 5000,
    text: "Hello",
    color: "",
    ticketId: "",
    file: ""
  }),

  methods: {
    send() {
      this.dialog = true;
      this.ticketId = this.$route.params.id;
      let formData = new FormData();
      formData.append("formFile", this.file);
      axios
        .post(Vue.prototype.$url + "/api/Upload/" + this.ticketId, formData, {
          headers: {
            "Content-Type": "multipart/form-data"
          }
        })
        .then(response => {
          console.log(response);
          this.dialog = false;
          this.color = "success";
          this.snackbar = true;
          this.text = "Succes";
          this.$router.go(0);
        })
        .catch(error => {
          console.log(error);
          this.dialog = false;
          this.color = "error";
          this.snackbar = true;
          this.text = "Error check console to see log";
        });
    },
    handleFileUpload() {
      this.file = this.$refs.file.files[0];
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