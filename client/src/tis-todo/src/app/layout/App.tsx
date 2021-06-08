import { Container } from 'semantic-ui-react';
import Navbar from '../layout/Navbar'
import TodoDashboard from '../../features/todos/dashboard/TodoDashboard'
import NotFound from '../../features/errors/NotFound'
import { observer } from 'mobx-react-lite';
import { Route, Switch } from 'react-router';
import HomePage from '../../features/home/homePage';
import ServerError from '../../features/errors/ServerError';

import { ToastContainer } from 'react-toastify';
import LoginForm from '../../features/users/LoginForm';
import { useStore } from '../stores/store';
import React, { useEffect } from 'react';
import LoadingComponent from './LoadingComponent';
import ModalContainer from '../common/modals/ModalContainer';




function App() {

  const {commonStore, userStore} = useStore();

  useEffect(() => {
    if (commonStore.token) {
      userStore.getUser().finally(() => commonStore.setAppLoaded());
    }else{
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore])

  if (!commonStore.appLoaded) return <LoadingComponent content='Loading app...' />

  return (
    <>
    <ModalContainer />
    <ToastContainer position='bottom-right' hideProgressBar />
      <Navbar />
      <Container style={{marginTop: '7em'}}>
        <Switch>
        <Route exact path='/' component={HomePage} />
        <Route path='/dashboard' component={TodoDashboard} />
        <Route path='/server-error' component={ServerError} />
        <Route path='/login' component={LoginForm} />
        <Route component={NotFound} />
        </Switch>
      </Container>
    </>
  );
}

export default observer(App);
