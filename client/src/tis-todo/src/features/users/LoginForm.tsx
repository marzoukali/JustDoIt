import { ErrorMessage, Form, Formik } from 'formik';
import { observer } from 'mobx-react-lite';
import { Button, Header, Label } from 'semantic-ui-react';
import TextInput from '../../app/common/form/TextInput';
import { useStore } from '../../app/stores/store';

export default observer(function LoginForm() {
    const {userStore} = useStore();
    return (
        <Formik
            initialValues={{username: '', password: '', error: null}}
            onSubmit={(values, {setErrors}) => userStore.login(values).catch(error => 
                setErrors({error: error.response.data}))}
        >
            {({handleSubmit, isSubmitting, errors}) => (
                <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                    <Header as='h2' content='Login to JustDoIt' color='teal' textAlign='center' />
                    <TextInput name='username' placeholder='Username' />
                    <TextInput name='password' placeholder='Password' type='password' />
                    <ErrorMessage 
                        name='error' render={() => 
                        <Label style={{marginBottom: 10}} basic color='red' content={errors.error}/>}
                    />
                    <Button loading={isSubmitting} positive content='Login' type='submit' fluid />
                </Form>
            )}
        </Formik>
    )
})