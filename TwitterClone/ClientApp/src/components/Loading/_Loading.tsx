import React from 'react';
import styled from 'styled-components';

import BlockUi from 'react-block-ui';
import 'react-block-ui/style.css';

export interface ILoadingOwmProps {
  renderChildren: boolean;
  children: React.ReactNode;
}

export interface ILoadingSelectedProps {
  isLoading: boolean;
}

export type ILoadingProps = ILoadingOwmProps & ILoadingSelectedProps;

export default function Loading({ children, isLoading, renderChildren }: ILoadingProps) {
  return (
    <StyledBlockUi
      tag="div"
      renderChildren={renderChildren}
      blocking={isLoading}
    >
      {children}
    </StyledBlockUi>
  )
}

const StyledBlockUi = styled(BlockUi)`
  height: 100vh;
`;
