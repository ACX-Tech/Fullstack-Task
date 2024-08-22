import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import HomePage from './pages/HomePage';
import TicketPage from './pages/TicketPage';
import NotFoundPage from './pages/NotFoundPage';

const Routes = () => (
  <Router>
    <Switch>
      <Route exact path="/" component={HomePage} />
      <Route path="/tickets/:userId" component={TicketPage} />
      <Route component={NotFoundPage} />
    </Switch>
  </Router>
);

export default Routes;
