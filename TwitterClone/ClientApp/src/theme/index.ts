import { createMuiTheme } from '@material-ui/core/styles';
import { createGlobalStyle } from 'styled-components';
import reset from 'styled-reset';

export const GlobalStyle = createGlobalStyle`
  ${reset}
`;

export default createMuiTheme({});
