<template>
  <v-container grid-list-xl text-xs-center>
    <v-layout row wrap>
      <v-flex xs12 offset-xs>
        <ViewTickets />
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
// @ is an alias to /src
import ViewTickets from "@/components/ViewTickets.vue";

export default {
  name: "View-Tickets",
  components: {
    ViewTickets
  }
};
</script>
