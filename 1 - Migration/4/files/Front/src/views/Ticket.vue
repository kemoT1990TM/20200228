<template>
  <v-container grid-list-xl text-xs-center>
    <v-layout row wrap>
      <v-flex xs8 offset-xs2>
        <TicketDetals />
        <v-btn color="success" @click="addComment()">Add Comment</v-btn>
        <br />
        <br />
        <AddFile />
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
// @ is an alias to /src
import TicketDetals from "@/components/TicketDetals.vue";
import AddFile from "@/components/AddFile.vue";
import Vue from "vue";
export default {
  name: "ticketDetals",
  components: {
    TicketDetals,
    AddFile
  },
  methods: {
    addComment() {
      this.$router.push({
        name: "addComment",
        param: { id: this.$route.params.id }
      });
    }
  }
};
</script>