import React from 'react';
// import styled from 'styled-components';

import PageContainer from '../../components/PageContainer';
import RegistrationForm from './RegistrationForm';

export interface IHomeProps {
  children: React.ReactNode;
}

export default function Registration() {
  return (
    <PageContainer maxWidth="xs">
      <RegistrationForm onSubmit={values => console.log(values)}/>
    </PageContainer>
  )
}
