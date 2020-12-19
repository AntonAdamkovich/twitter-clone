import React from 'react';
import styled from 'styled-components';

import {
  Container,
  ContainerProps,
} from '@material-ui/core';

export default function({ children, ...props }: ContainerProps) {
  return (
    <Wrapper>
      <ContentContainer {...props}>
        {children}
      </ContentContainer>
    </Wrapper>
  )
}

const Wrapper = styled.div`
  width: 100%;
  height: 100%;
`;

const ContentContainer = styled(Container)`
  height: 100%;
`;
