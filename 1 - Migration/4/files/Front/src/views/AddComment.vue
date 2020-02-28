<template>
  <v-container grid-list-xl text-xs-center>
    <v-layout row wrap>
      <v-flex xs8 offset-xs2>
        <AddComment />
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
// @ is an alias to /src
import AddComment from "@/components/AddComment.vue";
import Vue from "vue";
export default {
  name: "addComment",
  components: {
    AddComment
  },
  methods: {
    validate() {
      if (this.$refs.form.validate()) {
        this.snackbar = true;
      }
    }
  }
};
</script>