<template>
  <div>
    <v-data-table @click:row="clickedItem" v-model="selected" :headers="headers" :items="desserts">
      <v-progress-linear v-slot:progress color="blue" indeterminate></v-progress-linear>
      <template slot="items" slot-scope="props">
        <tr>
          <td>{{ props.item.Id }}</td>
          <td class="text-xs-right">{{ props.item.Email }}</td>
          <td class="text-xs-right">{{ props.item.Description }}</td>
          <td class="text-xs-right">{{ props.item.DateTime }}</td>
          <td class="text-xs-right">{{ props.item.TicketStatus }}</td>
        </tr>
      </template>
    </v-data-table>
    <v-dialog v-model="dialog" hide-overlay persistent width="300">
      <v-card color="primary" dark>
        <v-card-text>
          Please stand by
          <v-progress-linear indeterminate color="white" class="mb-0"></v-progress-linear>
        </v-card-text>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import Vue from "vue";
export default {
  data: () => ({
    selected: [],
    dialog: true,
    headers: [
      {
        text: "Id",
        align: "left",
        sortable: false,
        value: "Id"
      },
      { text: "Email", value: "Email", sortable: false },
      { text: "Description", value: "Description", sortable: false },
      { text: "DateTime", value: "DateTime" },
      { text: "TicketStatus", value: "TicketStatus" }
    ],
    desserts: []
  }),

  watch: {
    dialog(val) {}
  },

  created() {
    this.initialize();
  },

  methods: {
    initialize() {
      axios.get(Vue.prototype.$url + "/api/Ticket").then(response => {
        console.log(response.data);
        this.desserts = response.data;
        this.dialog = false;
      });
    },

    clickedItem(item) {
      console.log(item);
      console.log("TEST");
      console.log(item.Id);
      var id = item.Id;
      this.$router.push({ name: "AdminTicketwithID", params: { id } });
    }
  }
};
</script>