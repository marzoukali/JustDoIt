import {Button, Card} from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';




export default function TodoDetails(){

    const {todoStore} = useStore();

    return (
        <Card fluid>
            <Card.Content>
                <Card.Header>{todoStore.selectedTodoItem!.title}</Card.Header>
                <Card.Meta>
                    <span className='date'>{todoStore.selectedTodoItem!.createdAt}</span>
                </Card.Meta>
                <Card.Description>Matthew is a musician living in Nashville.</Card.Description>
            </Card.Content>
            <Card.Content extra>
               <Button.Group widths='2'>
                   <Button onClick={() => todoStore.openForm(todoStore.selectedTodoItem!.id)} basic color='blue' content='Edit' />
                   <Button onClick={todoStore.cancelSelectedTodoItem} basic color='grey' content='Cancel' />
               </Button.Group>
            </Card.Content>
        </Card>
    )
}