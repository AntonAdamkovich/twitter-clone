import React from 'react';
// import styled from 'styled-components';

import PageContainer from '../../components/PageContainer';
import LoginForm from './LoginForm';

export interface IHomeProps {
  children: React.ReactNode;
}

export default function Login() {
  return (
    <PageContainer maxWidth="xs">
      <LoginForm onSubmit={values => console.log(values)}/>
    </PageContainer>
  )
}
