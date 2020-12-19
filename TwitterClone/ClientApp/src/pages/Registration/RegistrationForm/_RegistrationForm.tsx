import React from 'react';
import { useForm } from 'react-hook-form';
import styled from 'styled-components';

import { Paper } from '@material-ui/core';
import { TextField, Button } from '@material-ui/core';

import TextInput from '../../../components/TextInput';

export interface IRegistrationFormValues {
  username: string;
  password: string;
}

export interface IRegistrationProps {
  onSubmit: (values: IRegistrationFormValues) => void;
}

export default function({ onSubmit }: IRegistrationProps) {
  const { handleSubmit, register } = useForm<IRegistrationFormValues>({
    mode: 'onBlur',
  });

  return (
    <StyledPaper>
      <StyledForm onSubmit={handleSubmit(onSubmit)}>
        <TextInput
          name="first-name"
          label="First name"
          placeholder="Enter you first name"
          ref={register({
            required: 'Please enter your first name',
          })}
        />
        <TextInput
          name="last-name"
          label="Last name"
          placeholder="Enter you last name"
          ref={register({
            required: 'Please enter your last name',
          })}
        />
        <TextInput
          type="date"
          name="date of birth"
          label="Date of birth"
          placeholder="Enter you date of birthe"
          ref={register({
            required: 'Please enter your last name',
          })}
        />
        <TextInput
          name="username"
          label="Username"
          placeholder="Enter you username"
          ref={register({
            required: 'Please enter your username',
          })}
        />
        <TextInput
          name="password"
          label="Password"
          placeholder="Enter you password"
          ref={register({
            required: 'Please enter your password',
          })}
        />
        <TextInput
          name="password-confirmation"
          label="Password confirmation"
          placeholder="Enter you password confirmation"
          helperText="Enter your password one more time"
          ref={register({
            required: 'Please enter your password confirmation',
          })}
        />
        <Button>submit</Button>
      </StyledForm>
    </StyledPaper>
  )
}

const StyledForm = styled.form`
  display: flex;
  flex-direction: column;
`;

const StyledPaper = styled(Paper)`
  padding: 25px;
`;
