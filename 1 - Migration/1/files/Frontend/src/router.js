import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import AddTicket from './views/AddTicket.vue'
import AdminTicket from './views/AdminTicket.vue'
import AdminTicketDetals from './views/AdminTicketDetals.vue'
import AddComment from './views/AddComment.vue'
import Ticket from './views/Ticket.vue';

Vue.use(Router)

export default new Router({
  routes: [{
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/AddTicket',
      name: 'AddTicket',
      component: AddTicket
    },
    {
      path: '/AdminTicket',
      name: 'AdminTicket',
      component: AdminTicket
    }, {
      path: '/AdminTicket/:id',
      name: 'AdminTicketwithID',
      component: AdminTicketDetals
    }, {
      path: '/Ticket/:id',
      name: 'TicketwithID',
      component: Ticket
    }, {
      path: '/AddComment/:id',
      name: 'addComment',
      component: AddComment
    }
  ]
})