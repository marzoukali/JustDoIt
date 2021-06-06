import { Formik, Form, Field, ErrorMessage } from 'formik';
import { values } from 'mobx';
import { observer } from 'mobx-react-lite';
import  {  ChangeEvent, useState } from 'react';
import {Button, FormField, Header, Label, Segment} from 'semantic-ui-react';
import * as Yup from 'yup';
import TextInput from '../../../app/common/form/TextInput';
import TextArea from '../../../app/common/form/TextArea';
import SelectInput from '../../../app/common/form/SelectInput';
import DateInput from '../../../app/common/form/DateInput';
import { categoryOptions } from '../../../app/common/options/categoryOptions';
import { useStore } from '../../../app/stores/store';







export default observer(function TodoForm(){

    const {todoStore} = useStore();

    const initialState = todoStore.selectedTodoItem ?? {
        id: '',
        title: '',
        description: '',
        createdAt:  '',
        dueAt: '',
        isComplete: false,
        creatorId: '',
        category: ''
    }

    const validationSchema = Yup.object({
        title: Yup.string().required('Todo title is required!'),
        category: Yup.string().required(),
    })
    

    const [todoItem, setTodoItem] = useState(initialState);
    


    function handleFormSubmit(){
       todoItem.id ? todoStore.updateTodoItem(todoItem) : todoStore.createTodoItem(todoItem);
    }


    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>)
    {
        const {name, value} = event.target;
        setTodoItem({...todoItem, [name]: value})
    }

    return (
        <Segment clearing>
            <Header content='Todo Details' sub color='teal' />

            <Formik
            validationSchema={validationSchema}
            enableReinitialize
             initialValues={todoItem}
              onSubmit={values => handleFormSubmit()}>
                {({handleSubmit, isValid, isSubmitting, dirty }) => (
            <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                <TextInput placeholder='Title' name='title' onChange={handleInputChange}  />
                <TextArea rows={3} placeholder='Description'  name='description' onChange={handleInputChange} />
                <SelectInput options={categoryOptions} placeholder='Category'  name='category' />
                <Field label='Completed' name='isComplete' onChange={handleInputChange}/>
                <DateInput 
                            placeholderText='Due At'  
                            name='dueAt' 
                            showTimeSelect
                            timeCaption='time'
                            dateFormat='MMMM d, yyyy h:mm aa'
                        />
                <Button disabled={isSubmitting || !dirty || !isValid} loading={todoStore.loading} floated='right' positive type='submit' content='submit' />
                <Button onClick={todoStore.closeForm} floated='right'  type='button' content='cancel' />
           </Form>
                )}
            </Formik>

        </Segment>
    )
})