import { useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import Navbar from '../layout/Navbar'
import TodoDashboard from '../../features/todos/dashboard/TodoDashboard'
import LoadingComponent from '../layout/LoadingComponent'
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';


function App() {

  const {todoStore} = useStore();

  useEffect(() => {
    todoStore.loadTodoItems();
  }, [todoStore])



  if(todoStore.loadingInitial) return <LoadingComponent content='Loading app' />

  return (
    <>
      <Navbar />
      <Container style={{marginTop: '7em'}}>
        <TodoDashboard />
      </Container>
    </>
  );
}

export default observer(App);
