import {Grid} from 'semantic-ui-react';
import TodoList from './TodoList';
import TodoDetails from '../details/TodoDetails';
import TodoForm from '../form/TodoForm';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';



export default observer(function TodoDashboard(){
    
    const {todoStore} = useStore();

    return (
        <Grid>
            <Grid.Column width='10'>
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