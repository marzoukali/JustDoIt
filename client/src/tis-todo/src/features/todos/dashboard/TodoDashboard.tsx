import {Button, Grid} from 'semantic-ui-react';
import TodoList from './TodoList';
import TodoDetails from '../details/TodoDetails';
import TodoForm from '../form/TodoForm';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import LoadingComponent from '../../../app/layout/LoadingComponent'




export default observer(function TodoDashboard(){
    
    const {todoStore} = useStore();

    useEffect(() => {
      todoStore.loadTodoItems();
    }, [todoStore])
  
  
  
    if(todoStore.loadingInitial) return <LoadingComponent content='Loading app' />

    return (
        <Grid>
            <Grid.Column width='10'>
                <Button onClick={() => todoStore.openForm()} positive content="+" fluid />
                <TodoList /> 
            </Grid.Column>
            <Grid.Column width='6'>
                {todoStore.selectedTodoItem && !todoStore.editMode &&
                 <TodoDetails/>}
                
                {todoStore.editMode && 
                <TodoForm />}
            </Grid.Column>
        </Grid>
    )
})