import { Container } from 'semantic-ui-react';
import Navbar from '../layout/Navbar'
import TodoDashboard from '../../features/todos/dashboard/TodoDashboard'
import NotFound from '../../features/errors/NotFound'
import { observer } from 'mobx-react-lite';
import { Route, Switch } from 'react-router';
import HomePage from '../../features/home/homePage';
import ServerError from '../../features/errors/ServerError';

import { ToastContainer } from 'react-toastify';


function App() {
  return (
    <>
    <ToastContainer position='bottom-right' hideProgressBar />
      <Navbar />
      <Container style={{marginTop: '7em'}}>
        <Switch>
        <Route exact path='/' component={HomePage} />
        <Route path='/dashboard' component={TodoDashboard} />
        <Route path='/server-error' component={ServerError} />
        <Route component={NotFound} />
        </Switch>
      </Container>
    </>
  );
}

export default observer(App);
