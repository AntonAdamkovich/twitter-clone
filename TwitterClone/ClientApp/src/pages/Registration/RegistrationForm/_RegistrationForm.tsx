import React from 'react';
import { useForm } from 'react-hook-form';
import styled from 'styled-components';

import { Paper, Button } from '@material-ui/core';
import TextInput from '../../../components/TextInput';

import { IRegistrationProps, IRegistrationFormValues } from './interfaces';

export default function({ onSubmit }: IRegistrationProps) {
  const { handleSubmit, register, errors } = useForm<IRegistrationFormValues>({
    mode: 'onBlur',
  });

  return (
    <StyledPaper>
      <StyledForm onSubmit={handleSubmit(onSubmit)}>
        <TextInput
          name="firstName"
          label="First name"
          placeholder="Enter you first name"
          errorMessage={errors.firstName?.message}
          ref={register({
            required: 'Please enter your first name',
          })}
        />
        <TextInput
          name="lastName"
          label="Last name"
          placeholder="Enter you last name"
          errorMessage={errors.lastName?.message}
          ref={register({
            required: 'Please enter your last name',
          })}
        />
        <TextInput
          type="date"
          name="dateOfBirth"
          label="Date of birth"
          placeholder="Enter you date of birthe"
          errorMessage={errors.dateOfBirth?.message}
          ref={register({
            required: 'Please enter your last name',
          })}
        />
        <TextInput
          name="username"
          label="Username"
          placeholder="Enter you username"
          errorMessage={errors.username?.message}
          ref={register({
            required: 'Please enter your username',
          })}
        />
        <TextInput
          name="password"
          label="Password"
          placeholder="Enter you password"
          errorMessage={errors.password?.message}
          ref={register({
            required: 'Please enter your password',
          })}
        />
        <TextInput
          name="passwordConfirmation"
          label="Password confirmation"
          placeholder="Confirm your password"
          errorMessage={errors.passwordConfirmation?.message}
          ref={register({
            required: 'Please enter your password confirmation',
          })}
        />
        <Button type="submit">submit</Button>
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
  width: 100%;
`;
