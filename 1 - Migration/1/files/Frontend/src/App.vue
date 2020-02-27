<template>
  <v-app>
    <v-app-bar app>
      <v-toolbar-title class="headline text-uppercase">
        <span>Ticket Service</span> &nbsp;
        <span class="font-weight-light">DEMO</span> &nbsp;
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <div id="nav">
        <router-link to="/">Home</router-link>&nbsp;
        <router-link to="/Addticket">Add Ticket</router-link>&nbsp;
        <router-link to="/AdminTicket">Admin Ticket</router-link>&nbsp;
      </div>
    </v-app-bar>

    <v-content>
      <router-view />
    </v-content>
  </v-app>
</template>

<script>
</script>
